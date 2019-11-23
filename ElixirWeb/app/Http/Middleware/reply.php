<?php

namespace App\Http\Middleware;

use Closure;
use Session;
class reply
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
        $tel = Session::get('userDetails');
        $stat = $tel[0]->name;
        if ($stat == 'Admin') {
            return $next($request);
        }else {
            return back()->with('error','forbidden access');
        }
    }
}
