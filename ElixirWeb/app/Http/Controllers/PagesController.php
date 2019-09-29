<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\profiles;

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
       return view('profiles')->with('profile',$profile);
    }
}
