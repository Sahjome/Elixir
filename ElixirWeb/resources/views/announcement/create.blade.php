<?php
    $title = 'Create'; //this should be the type
    $page = 'New Special'; //this should be the title
?>
@extends('layout.app')
@section('section')
<!-- contact form start -->
<section class="contact-form section">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-lg-8 text-center">
                <div class="section-title">
                    <div class="divider mb-3"></div>
                    <h2>Special</h2>
                    <p class="mt-3">Lorem ipsum dolor sit amet, consectetur adipisicing elit. In error reprehenderit quam enim obcaecati, repudiandae officia a cumque nemo provident!</p>
                </div>
            </div>
        </div>
         <div class="row justify-content-center pb-5">
            <div class="col-lg-9 text-center">
                <form id="contact-form" method="POST" action="/saveA" >
                    @csrf
                    <div class="form-row">
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div class="form-group">
                                <label class="control-label float-left">Title: </label>
                                <input type="text" name="title" class="form-control" placeholder="Title..." required>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div class="form-group">
                                <label class="control-label float-left">Type: </label>
                                <select name="type" class="form-control" aria-placeholder="Type" required>
                                    <option disabled selected value>---select---</option>
                                    <option>Announcement</option>
                                    <option>Event</option>
                                </select>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div class="form-group">
                                <label class="control-label float-left">Description</label>
                                <textarea name="description" class="form-control" maxlength="60" placeholder="not more than 60 characters..." rows="3" required></textarea>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <div class="form-group-2">
                                <textarea name="details" id="summary-ckeditor" class="form-control" rows="8" placeholder="Your Message"></textarea>
                            </div>
                            <div class="form-group col-lg-6 col-md-6 col-sm-12">
                                <label for="exampleInputFile" class="float-left control-label">File input</label>
                                <input type="file" name="file" class="form-control-file" id="exampleInputFile" aria-describedby="fileHelp">
                                <small id="fileHelp" class="form-text text-muted float-left">.jpg|.png only</small>
                            </div>
                            <div class="text-center">
                                <button class="btn btn-main mt-3 float-left" type="submit">Submit</button>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
@endsection