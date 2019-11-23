<?php
$title = 'Counselling'; 
$page = 'Password';
?>
@extends('layout.app')

@section('section')
    <section class="section services">
        <div class="container">
            <div class="row justify-content-center pb-5">
                <div class="col-lg-10 text-center">
                    <form method="POST" action="/messages">
                        @csrf
                        <p>Sign in to speak with the Senior Pastor</p>
                        <div class="form-row">
                            <div class="col-lg-12 col-md-12 col-sm-12">
                                <div class="form-group col-lg-6" style="display:inline-block">
                                    <label class="form-label float-left">Username:</label>
                                    <input class="form-control" name="username" value={{$username}} readonly>
                                </div>
                            </div>
                            <div class="col-lg-12 col-md-12 col-sm-12">
                                <div class="form-group col-lg-6" style="display:inline-block">
                                    <label class="form-label float-left">Password:</label>
                                    <input class="form-control" name="password" type="password">
                                </div>
                            </div>
                        </div>
                        <button type="submit" class="btn btn-main mt-3">Login</button>
                    </form>
                </div>
            </div>
        </div>
    </section>
@endsection