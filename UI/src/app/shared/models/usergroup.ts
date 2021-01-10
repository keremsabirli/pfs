import Shared from "./shared";
import User from "./user";

export default interface UserGroup extends Shared {
    Name: string;
    Creator: User;
    Members: User[];
}