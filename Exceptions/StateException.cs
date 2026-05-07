using ResponseState.Enums;

namespace ResponseState.Exceptions;

public class StateException : Exception
{
    public StateCode StateCode { get; set; }
    public string DetailMessage { get; set; }

    public override string Message => DetailMessage ?? StateCode?.Message ?? base.Message;

    public StateException(StateCode stateCode)
    {
        StateCode = stateCode;
        DetailMessage = stateCode.Message;
    }

    public StateException(StateCode stateCode, string detailMessage)
    {
        StateCode = stateCode;
        DetailMessage = detailMessage;
    }

    public StateException(StateCode stateCode, params object[] formatArgs)
    {
        StateCode = stateCode;
        if (formatArgs != null && formatArgs.Length > 0)
        {
            DetailMessage = string.Format(stateCode.Message, formatArgs);
        }
        else
        {
            DetailMessage = stateCode.Message;
        }
    }
}