import "../enums/userStatus.enum.tsp";

model User{
    userId: int32;
    email: string;
    firstName: string;
    lastName: string;
    companyId: int32;
    status: Enums.UserStatus;
}