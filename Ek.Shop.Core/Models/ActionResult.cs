using Ek.Shop.Core.Enums;
using System.Collections.Generic;

namespace Ek.Shop.Core.Models
{
    public class ActionResult<TResult>
    {
        public bool Success { get; private set; }

        public bool Failure => !Success;

        // Every warning message have to be displayed in modelstateErrors
        public Dictionary<string, DetailError> ErrorMessages { get; private set; } = new Dictionary<string, DetailError>();

        public TResult Object { get; private set; }

        public static ActionResult<TResult> Ok(TResult result)
        {
            return new ActionResult<TResult> { Success = true, Object = result };
        }

        // Temporary method since I have no idea how to implement this method properly to take phrase by name 
        public static ActionResult<TResult> Error()
        {
            return new ActionResult<TResult>
            {
                Success = false,
                ErrorMessages = new Dictionary<string, DetailError>()
                {
                    { "headerErrors", new DetailError(DetailErrorTypes.HeaderErrors, "Internal Error.") }
                }
            };
        }

        public static ActionResult<TResult> Error(Dictionary<string, DetailError> errorMessages)
        {
            return new ActionResult<TResult> { Success = false, ErrorMessages = errorMessages };
        }
    }
}
