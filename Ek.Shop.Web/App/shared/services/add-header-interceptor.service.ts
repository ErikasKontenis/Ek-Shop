import {
    HttpEvent,
    HttpInterceptor,
    HttpHandler,
    HttpRequest,
} from '@angular/common/http';
import { Observable } from "rxjs/Observable";

export class AddHeaderInterceptor implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // Clone the request to add the new header
        const clonedRequest = req.clone({ headers: req.headers.set('IsAdmin', 'true') });

        // Pass the cloned request instead of the original request to the next handle
        return next.handle(clonedRequest);
    }
}
