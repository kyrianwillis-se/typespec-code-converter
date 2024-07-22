using TypeSpec.Http;

@error
model ApiError<T = int32> {
  @statusCode statusCode : T,
  @minValue(400)
  @maxValue(499)
  code: int32;

  message: string;
}
