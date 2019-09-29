<?php
    $title = 'Create'; //this should be the type
    $page = 'New Media'; // this should be the title
    $hint = '';
    $opt = ['Audio','Diet','Document','Video'];
    /*if(['type'] == $opt[0]){
        $hint = 'mp3|mp4 only';
    }
    elseif(['type'] == $opt[1] ){
        $hint = 'jpg|png only';
    }
    elseif(['type'] == $opt[2] ){
        $hint = 'txt|docx|pdf only';
    }
    elseif(['type'] == $opt[3] ){
        $hint = 'mp4 only';
    } */
    if(['type'] == $opt[0]){
        $hint = 'mp3|mp4 only';
    }
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
                    <h2>Media</h2>
                    <p class="mt-3">Lorem ipsum dolor sit amet, consectetur adipisicing elit. In error reprehenderit quam enim obcaecati, repudiandae officia a cumque nemo provident!</p>
                </div>
            </div>
        </div>

         <div class="row justify-content-center pb-5">
            <div class="col-lg-9 text-center">
                <form id="contact-form" method="POST" action="/saveM" >
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
                                <select name="type" id="type" data-target="#fileHelp" class="form-control" aria-placeholder="Type" required>
                                    <option disabled selected value>---select---</option>
                                    <option>Audio</option>
                                    <option>Diet</option>
                                    <option>Document</option>
                                    <option>Video</option>
                                </select>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div class="form-group">
                                <label class="control-label float-left">Description</label>
                                <textarea name="description" class="form-control" maxlength="60" placeholder="not more than 60 characters..." rows="3" required></textarea>
                            </div>
                            
                        </div>
                        <span style="border-left:solid 1px; margin:30px 0px 0px 60px" class="form-group col-lg-4 col-md-4 col-sm-12">
                            <label for="exampleInputFile" class="float-left control-label">Featured image</label>
                            <input type="file" name="image" class="form-control-file" id="exampleInputFile" aria-describedby="fileHelp">
                            <small id="image" class="form-text text-muted float-left">.jpg|.png only</small>
                        </span>
                        <div class="col-lg-12 col-md-12 col-sm-12">
                           
                            <div class="form-group col-lg-6 col-md-6 col-sm-12">
                                <label for="exampleInputFile" class="float-left control-label">File input</label>
                                <input type="file" name="file" class="form-control-file" id="exampleInputFile" aria-describedby="fileHelp">
                                <small id="fileHelp" class="form-text text-muted float-left">{{$hint}}</small>
                            </div>
                            <br>
                            <hr>
                            
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
    