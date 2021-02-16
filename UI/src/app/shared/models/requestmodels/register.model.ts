import { UserType } from "../enum/usertype.enum";

export default interface RegisterModel {
    Name: string;
    Surname: string;
    Email: string;
    Password: string;
    UserType: UserType;
}