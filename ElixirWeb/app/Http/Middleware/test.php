<?php

namespace App\Http\Middleware;

use Closure;
use Session;
class test
{
    /**
     * Handle an incoming request.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  \Closure  $next
     * @return mixed
     */
    public function handle($request, Closure $next)
    {
        if($request->session()->has("userDetails")){
            return $next($request);
        }
        return redirect('/')->with('error', ':X Only Admin is allowed here.');
    }
}
