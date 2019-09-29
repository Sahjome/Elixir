<?php
    //dd($anno['type']);
    $title = $anno['type']; //this should be the type
    $page = $anno['title']; // this should be the title 
    $ann0 = [$ann1, $ann2, $ann_1];
    /*foreach($ann0 as $anni){
        for($i = 1; $i < 4; $i++){
            @if($anni != null)
                @section('image'.$i)
                {{$anni['file']}}
                @endsection
                @section('/show/'.$i)
                {{$anni['id']}}
                @endsection
                @section('title'.$i)
                {{$anni['title']}}
                @endsection
                
                @if($i==1)
                    @section('/show/+'.$i)
                    {{$anni['id']}}
                    @endsection
            }
        }
    @endforeach
    dd($ann0);*/
?>

@extends('layout.inner')
    @section('title')
    {{$anno['description']}} 
    @endsection
    @section('featured image')
    {{$anno['file']}}
    @endsection
    @section('body')
    {{$anno['details']}}
    @endsection
    @if ($ann1 != null)
        @section('image1')
        {{$ann1['file']}}
        @endsection
        @section('/show/1')
        {{$ann1['id']}}
        @endsection
        @section('title1')
        {{$ann1['title']}}
        @endsection
        @section('/show/+1')
        {{$ann1['id']}}
        @endsection
    @else
        @section('/show/1')
        {{$anno['id']}}
        @endsection
        @section('title1')
        {{'No '.$anno['type']}}
        @endsection
        @section('/show/+1')
        {{$anno['id']}}
        @endsection  
    @endif
    
    @if ($ann2 != null)
        @section('image2')
        {{$ann2['file']}}
        @endsection
        @section('/show/2')
        {{$ann2['id']}}
        @endsection
        @section('title2')
        {{$ann2['title']}}
        @endsection
    @else
        @section('/show/2')
        {{$anno['id']}}
        @endsection
        @section('title2')
        {{'No '.$anno['type']}}
        @endsection
    @endif
    @if ($ann_1 != null)
        @section('image3')
        {{$ann_1['file']}}
        @endsection
        @section('/show/3')
        {{$ann_1['id']}}
        @endsection
        @section('title3')
        {{$ann_1['title']}}
        @endsection
        @section('/show/-1')
        {{$ann_1['id']}}
        @endsection
    @else
        @section('/show/3')
        {{$anno['id']}}
        @endsection
        @section('title3')
        {{'No '.$anno['type']}}
        @endsection
        @section('/show/-1')
        {{$anno['id']}}
        @endsection
    @endif
    
    
    
