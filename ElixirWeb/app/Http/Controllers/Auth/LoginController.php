<?php

namespace App\Http\Controllers\Auth;

use App\Http\Controllers\Controller;
use Illuminate\Foundation\Auth\AuthenticatesUsers;
use ILluminate\Support\Facades\Auth;
use Illuminate\Support\Facades\Session;
use Hash;
if (!isset($_SESSION)) {
    session_start();
}
class LoginController extends Controller
{
    /*
    |--------------------------------------------------------------------------
    | Login Controller
    |--------------------------------------------------------------------------
    |
    | This controller handles authenticating users for the application and
    | redirecting them to your home screen. The controller uses a trait
    | to conveniently provide its functionality to your applications.
    |
    */

    use AuthenticatesUsers;

    /**
     * Where to redirect users after login.
     *
     * @var string
     */
    protected function redirectTo(){
        // $username = {{Auth::user()->name}};
        // $email = {{Auth::user()->email}};
        // dd($username.' '.$email);
        // Session::put('userDetails',[
        //     'name' => Auth::user()->name,
        //     'email' => Auth::user()->email
        // ]);
        if(Auth::check()){
            return redirect('/media')->with('success','Welcome.');
        Session::start();
        }
        else {
            return redirect('/')->with('error','Not');
        }
    } 
    /**
     * Create a new controller instance.
     *
     * @return void
     */
    public function __construct()
    {
        $this->middleware('guest')->except('logout');
    }
}
// $pass = $_REQUEST['password'];
        // $entry = $_REQUEST['entry'];
        // $login = User::where('email','or','name','=',$entry,'and','password','=',$pass);
        // $credentials = ['email'=> $request->entry,
        // 'password' => $request->password];
        // dd($login);
        // if(Auth::attempt([$credentials])){
        //     Session::put('userDetails',$credentials);
        //     return redirect('/')->with('success','Welcome.');
        //     Session::start();
        // }
        // else {
        //     return back()->with('error','Login Failed.');
        // }