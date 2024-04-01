fun = @(x) exp(-x.^2).*log(x).^2;
q = integral(fun,0,inf);