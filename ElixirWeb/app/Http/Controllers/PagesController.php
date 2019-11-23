<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\profiles;
use Illuminate\Support\Facades\Session;
use App\Messages;
use App\Media;

class PagesController extends Controller
{
    public function index()
    {
        return view('home');
    }

    public function show()
    {
        return view('pages.show');
    }

    public function special()
    {
        return view('pages.special');
    }

    public function contact()
    {
        return view('contact');
    }

    public function diet()
    {
        return view('diet');
    }
    public function download(){
        return view('download');
    }

    public function about(){
        return view('about');
    }

    public function add(){
        return view('announcement.add');
    }

    public function profiles()
    {
        //$profile = profiles::all();
       $profile = Profiles::orderby('Surname','asc')->simplePaginate(25);
       return view('profiles')->with('profile', $profile);
    }

    public function Password($username, Request $request)
    {
        //take the message and the username and reply to the particular user
        $uri = $request->path();
        return view('password')->with('username', $username);
    }

    public function Message(Request $request)
    {
        $username = $request->username;
        $password = $request->password;
        //dd($username);
        $check = Profiles::where('Username', '=', $username)->where('Password', '=', $password)->get();
        //dd($check);
        if ($check) {
            Session::put('chatDetails', $check);
            //Session::put('userDetails', $check);
            $messages = Messages::where('pair', '=', 'Pastor-'.$username)->orderBy('created_at', 'asc')->get();
            $mess = [
                'message' => $messages,
                'username' => $username
            ];
            // dd($username);
            return view('pages.counselling')->with($mess);
        } else {
           return back()->with('error','Only registered students can use the counselling feature.
           You can download the app if you\'re a student.');
        }
    }

    public function CreateReply(Request $request)
    {
        try {
            $pair = ($request->to == 'Pastor')? 'Pastor-'.$request->from : 'Pastor-'.$request->to;
            // dd($pair);            
            $message = new Messages();
            $message->to = $request->to;
            $message->from = $request->from;
            $message->pair = $pair;
            $message->message = $request->message;
            $save = $message->save();
            if ($save) {
                $uri = $request->url();
                return back()->with('success','message sent');
            } else {
                return back()->with('error','message not sent');
            }
        } catch (\Throwable $th) {
            return back()->with('error','message not sent');            
        }
    }

    public function Hasher(Request $request)
    {
        //$pass = hash($request->password);
        $pass = 'http://localhost:8000/api/pail/328hn/sdaiuh2';
        $slip = strpos($pass, 'api');
        $maine = substr($pass, 0, strpos($pass, 'api'));
        dd($maine);
    }

    public function reply(Request $request)
    {
        $username = $request->username;
        // $messa = Messages::where("pair", "=", "Pastor-kope")->get();
        $messa = Messages::where('pair', '=', 'Pastor-'.$username)->orderBy('created_at', 'asc')->get();
        //$messa = Profiles::where('Username', '!=', '', )->orderBy('created_at', 'desc')->get();
        $mess = [
            'message' => $messa,
            'username' => $username
        ];
        // dd($messa);
        return view('pages.counselling')->with($mess);
    }
}
