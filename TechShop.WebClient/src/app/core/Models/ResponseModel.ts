export class ResponseModel<T>
{
    public resultType! : ResultType
    public data! : T
    public errors! : Array<string>
}


export enum ResultType
{
    Ok,
    Invalid,
    Unauthorized,
    NotFound,
    PermissionDenied,
    Unexpected,
    InternalError
}