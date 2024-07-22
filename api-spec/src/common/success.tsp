using TypeSpec.Http;

//indicates a successful response and status code with 200 being the default value
model Success<T, Code extends int32 = 200> {
    @statusCode statusCode: Code;
    @body response: T;
}