import { throwError } from "rxjs";
import { AppError } from "./app-error";
import { BadRequestError } from "./bad-request-error";
import { NotFound } from "./not-found-error";

export class ErrorHandlingService {
    protected handleError(error: any) {
        if(error.status === 400) {
          return throwError(() => new BadRequestError(error))
        }
        if(error.status === 404) {
          return throwError(() => new NotFound(error))
        }
    
        return throwError(() => new AppError(error))
      }
}