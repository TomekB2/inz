import { HttpInterceptorFn } from '@angular/common/http';

export const customInterceptor: HttpInterceptorFn = (req, next) => {
  const token = localStorage.getItem('token');
  const cloneReq = req.clone({
    setHeaders:
    {
      Authorization: `${token}`
    }
  });
  return next(cloneReq);
};
