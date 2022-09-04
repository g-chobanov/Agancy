import { ErrorHandler } from "@angular/core"
import { NotFoundError } from "rxjs";
import { AppError } from "./app-error";

export class AppErrorHandler implements ErrorHandler {
    handleError(error: any): void {
        if (error instanceof NotFoundError) {
            alert("Page was not found");
            console.log(error);
            return;
        }
        alert("Whoops. Unexprected error.")
        console.log(error);
    }

}