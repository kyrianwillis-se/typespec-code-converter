import "../../enums/userStatus.enum.tsp";

model UserUpdateRequest{
    userId: int32;
    firstName: string;
    lastName: string;
    status: Enums.UserStatus;
}