<?php

namespace App\Http\Controllers;
use App\User;
use Illuminate\Support\Facades\Session;
use Auth;
use DB;
use Illuminate\Http\Request;
if (!isset($_SESSION)) {
    session_start();
}
class LoginController extends Controller
{
    public function index(Request $request)
    {
        $credentials = ['email'=> $request->entry,
         'password' => $request->password];
        $login = DB::select("select * from users where email = ? and password = ? ", [$request->entry,$request->password]);
        if(!empty($login)){
            Session::put('userDetails',$credentials);
            return redirect('/')->with('success','Welcome.');
            Session::start();
        }
        return back()->with('error','Login Failed.');
        
    }

    public function logout()
    {
        Session::flush();
        session_destroy();
        return redirect('/')->with('success', 'Successfully logged out.');
    }
    public function users($pass, $entry)
    {
        //$var = 1;
        $credentials = ['email'=> $entry,
         'password' => $pass];
        //$login = User::find('email','from','name','=',$entry,'and','password','=',$pass);
        $login = DB::select("select * from users where email = ? and password = ? ", [$entry,$pass]);
        if(!empty($login)){
            Session::put('userDetails',$credentials);
            return redirect('/')->with('success','Welcome.');
            Session::start();
        }
        return back()->with('error','Login Failed.');
        //$see = User::find($var);
        //dd($login);
    }
}
