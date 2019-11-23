<?php
    $title = 'Counselling';
    $page = 'Messages with '.$username;

    if (!empty(Session::get('chatDetails')))
    {
        $to = 'Pastor';
        $from = $username;
    }
    else
    {
        $to = $username;
        $from = 'Pastor';
    }
?>
@extends('layout.app')
@section('section')
    <section class="section services">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-8 text-center">
                    <div class="section-title">
                        <div class="divider mb-3"></div>
                        <h5>Chat with {{$to}}</h5>
                    </div>
                </div>
            </div>

            <div class="row justify-content-center pb-5">
                @if (!$message->isEmpty())
                    <div class="col-lg-12 col-md-12 col-sm-12 text-center">
                        @foreach ($message as $item)
                            @if ($item->from == $to)
                                <div class="col-lg-6 col-md-6 col-sm-6" style="background:green">
                                    <div class="media form-control align-items-center mb-4">
                                        <p>From: {{$to}}</p>
                                        <div class="media-body">
                                            <span class="letter-spacing text-sm">{{$item->message}}</span>
                                        </div>
                                    </div>
                                </div>
                            @else
                            <div class="col-lg-6 col-md-6 col-sm-6" style="background:orange">
                                    <div class="media form-control align-items-center mb-4">
                                        <p>From: {{$from}}</p>        
                                        <div class="media-body">
                                            <span class="letter-spacing text-sm">{{$item->message}}</span>
                                        </div>
                                    </div>
                                </div>
                            @endif
                        @endforeach
                    </div>
                @else
                    <p><center>No messages between the {{$from}} and {{$to}}</center></p>
                @endif
            </div>
            <div class="row justify-content-center pb-5">
                <div class="col-lg-12 col-md-12 col-sm-12 text-center">
                    <form class="form" method="POST" action="/send">
                        @csrf
                        <div class="form-row">
                            <div class="col-lg-6 col-md-6 col-sm-12">
                                <input type="hidden" name="from" value={{$from}}>
                                <input type="hidden" name="to" value={{$to}}>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-12">
                                <div class="form-group col-lg-10 col-md-10 col-sm-12">
                                    <label class="control-label float-left" name="to">To: {{$to}}</label>
                                    <textarea name="message" class="form-control" maxlength="180" placeholder="not more than 180 characters..." rows="3" required></textarea>
                                </div>
                                <button class="btn btn-main col-lg-2 col-md-2 col-sm-12" style="padding-top: 0px;padding-left: 3px;height: 0px;width: 9%;border-radius:18px;" type="submit">Send</button>
                            </div>
                        </div>
                    </form>
                </div>  
            </div>
        </div>
    </section>
@endsection