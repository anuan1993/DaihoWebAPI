using Microsoft.VisualBasic;
using System.Net;
using DaihoWebAPI.Models.Response;
using DaihoWebAPI.Constants;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;

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
                Status = Constant.Status.StatusOK,
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
                Code = code,
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
