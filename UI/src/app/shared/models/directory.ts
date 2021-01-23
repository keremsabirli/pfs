import Shared from "./shared";
import _File from "./file";

export default interface Directory extends Shared {
    Name: string;
    ChildFiles: _File[];
    ChildDirectories: Directory[];
    ParentDirectory: Directory;
}