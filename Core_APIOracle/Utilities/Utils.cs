using Microsoft.VisualBasic;
using System.Net;
using DaihoWebAPI.Models.Response;
using DaihoWebAPI.Constants;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;
using Oracle.ManagedDataAccess.Client;

namespace DaihoWebAPI.Utilities
{
    public class Utils
    {
        public static Responses NewSuccessResponse(Object? data, string? message)
        {
            return new Responses
            {
                Data = data,
                Success = true,
                Message = message,
                Status = Status.StatusOK,
                Code = (int)HttpStatusCode.OK,
                //Pagination = pagination,
            };
        }

        public static Responses NewErrorResponse(Object? data, string? message, string status, int code)
        {
            return new Responses
            {
                Data = data,
                Success = false,
                Message = message,
                Status = status,
                Code =(int) code,
            };
        }
        public class Errors
        {
            public static bool IsDuplicateError(Exception e)
            {
                if (e.InnerException is SqlException sqlException)
                {
                    return sqlException.Number == 2627 || sqlException.Number == 2601;
                }

                return false;
            }

            public static void WrapDuplicateError(Exception e, string message)
            {
                if (e.InnerException is SqlException sqlException)
                {
                    if (sqlException.Number == 2627 || sqlException.Number == 2601)
                    {
                        throw new DuplicateRecordException($"{message}: {ExtractValue(sqlException)}");
                    }
                    throw e;
                }
            }

            public static bool IsDuplicateRecordException(Exception e)
            {
                // Check if the exception or any of its inner exceptions is related to a unique constraint violation in Oracle
                var oracleException = e as OracleException ?? e.InnerException as OracleException;
                if (oracleException != null)
                {
                    // Check if the Oracle error number corresponds to a unique constraint violation
                    // ORA-00001 is the error code for unique constraint violation in Oracle
                    return oracleException.Number == 1;
                }

                return false;
            }

            public static string? ExtractValue(Exception? e)
            {
                if (e == null)
                {
                    return null;
                }

                string pattern = @"\(([^)]*)\)";

                Regex regex = new Regex(pattern);
                Match match = regex.Match(e.Message);
                if (match.Success)
                {
                    return match.Value;
                }

                return null;
            }
        }
    }

    [Serializable]
    internal class DuplicateRecordException : Exception
    {
        public DuplicateRecordException()
        {
        }

        public DuplicateRecordException(string? message) : base(message)
        {
        }

        public DuplicateRecordException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DuplicateRecordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
