<?php
    $title = 'Media';
    $page = 'Media';
    $url = 'delM/';
    
    //get from the announcement table everything so we can populate
    //using foreach with pagination at the end of the page
    //['title','type','description','file','image','diet']
?>
@extends('layout.app')

@section('section')

<!-- Section Blog start -->
<section class="section blog bg-gray">
	<div class="container">
		<div class="row">
            @if (count($ann0)>0)
                @foreach ($ann0 as $ann)
                    <div class="col-lg-4 col-md-6">
                        <article class="card border-0 rounded-0 mb-4">
                            <img src={{$ann->file}} alt="" class="img-fluid">
        
                            <div class="mt-3 px-4 py-3 ">
                                <div class="blog-post-meta text-capitalize mb-2">
                                    <span class="post-meta date-meta mr-2">
                                    <i class="ti-calendar mr-2"></i>{{$ann->created_at}}</span> 
        
                                    <span class="post-meta author"><i class="ti-user mr-2 text-muted"></i>Admin</span>
                                </div>
                                <a href={{'media/show/'.$ann->id}}><h4 class="mb-3 font-secondary">{{$ann->title}}</h4></a>
                                    
                                <p class="mb-4">{{$ann->description}}</p>
        
                                <a href={{'media/show/'.$ann->id}} class="text-color mb-3 d-block">
                                    <i class="ti-minus mr-2"></i> Read More
                                </a>
                            </div>
                            @if (!empty(Session::get('userDetails')))
                            <div class="container">
                            <div class="row">
                                <span class="row justify-content-center">
                                    <form class="col float-left" method="GET" action={{'media/edit/'.$ann->id}}>
                                        @csrf
                                        <input type="hidden" _method="PUT">
                                        <button type="submit" style="margin-left:25px; padding-right:45px; padding-left:45px;" class="btn btn-info mt-3">edit</button>
                                    </form>
                                    <button  type="button"
                                    class="btn btn-danger mt-3 col float-right"  data-toggle="modal" data-target="#myModalQuestion">delete</button>
                                </span>
                            </div>
                        </div>
                        <?php $id = $ann->id; ?>
                        @include('inc.modal')
                       @endif
                        </article>
                       
                    </div> 
                @endforeach
            @else
                {{'nothing to display here'}}
            @endif
			

        </div>

        <!---------//pagination here-------->
        <div class="row justify-content-center mt-5">
            <nav aria-label="Page navigation ">
                <ul class="pagination justify-content-center">
                    {{$ann0->links()}}
                </ul>
            </nav>
        </div>
	</div>
</section>

@endsection