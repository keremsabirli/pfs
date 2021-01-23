import Directory from "./directory";
import Shared from "./shared";

export default interface File extends Shared {
    Name: string;
    Extension: string;
    ParentDirectory: Directory;
}