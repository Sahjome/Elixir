<?php

namespace App\Http\Controllers;

use Illuminate\Support\Facades\Mail;
use App\Http\MailSender;
use Illuminate\Http\Request;

class MailController extends Controller
{
    public function send($email)
    {
        Mail::to($email)->send(new MailSender());
        if (Mail::failures()) {
            $msg = 'mail wasn\'t sent.';
            return response()->json($msg);
        }else {
            $msg = 'mail sent.';
            return response()->json($msg);
        }
    }
}
