@extends('layout.app')

@section('section')
<section class="section blog bg-gray">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-9 col-md-12">
                    <div class="row">
                        <div class="col-lg-12">
                            <h5>@yield('title')</h5>
                            <!---insert any image available here---->
                            
                            <img src="@yield('featured image')" alt="" class="img-fluid">
                            <!----insert the body here---->
    
                            <p class="mt-4"> @yield('body')</p>
                            <!------tags or media type------>
                            <div class="post-tags my-5 text-uppercase font-size-12 letter-spacing text-center">
                                <a href="#" class="mr-2 text-black"><i class="ti-bookmark mr-2 text-color"></i>Yoga </a>
                                <a href="#" class="mr-2 text-black"><i class="ti-bookmark mr-2 text-color"></i>Meditation</a>
                                <a href="#" class="mr-2 text-black"><i class="ti-bookmark mr-2 text-color"></i>Nutirtion</a>
                                <a href="#" class="mr-2 text-black"><i class="ti-bookmark mr-2 text-color"></i>Healthy diet</a>
                            </div>
                            
                            <!------social media handles------>
                            <div class="border-top border-bottom py-4 text-center social-share">
                                <h4 class="mb-4 font-secondary text-uppercase font-weight-normal">Share this post?</h4>
                                <ul class="list-inline mb-0">
                                    <li class="list-inline-item"><a href="#"><i class="ti-facebook"></i></a></li>
                                    <li class="list-inline-item"><a href="#"><i class="ti-twitter"></i></a></li>
                                    <li class="list-inline-item"><a href="#"><i class="ti-instagram"></i></a></li>
                                </ul>
                            </div>
                            <!---------show 3 more posts using +1------>
                            <div class="mt-4 py-4 text-center social-share">
                                <h4 class="mb-5 font-secondary text-uppercase font-weight-normal">More</h4>
                                <div class="row">
                                    <div class="col-lg-4 col-md-6">
                                        <article class="card border-0 rounded-0 mb-4">
                                            <img src=@yield('image1') alt="" class="img-fluid">
                                    
                                            <div class="mt-3 px-4 py-3">
                                                <span class="post-meta author text-capitalize text-sm"><i class="ti-user mr-2 text-muted"></i>Admin</span>
                                                <a href=@yield('/show/1')><h5 class="font-secondary mt-2">@yield('title1')</h5></a>
                                            </div>
                                        </article>
                                    </div>
                                    <div class="col-lg-4 col-md-6">
                                        <article class="card border-0 rounded-0 mb-4">
                                            <img src=@yield('image2') alt="" class="img-fluid">
                                    
                                            <div class="mt-3 px-4 py-3">
                                                <span class="post-meta author text-capitalize text-sm"><i class="ti-user mr-2 text-muted"></i>Admin</span>
                                                <a href=@yield('/show/2')><h5 class="font-secondary mt-2">@yield('title2')</h5></a>
                                            </div>
                                        </article>
                                    </div>
                                    <div class="col-lg-4 col-md-6">
                                        <article class="card border-0 rounded-0 mb-4">
                                            <img src=@yield('image3') alt="" class="img-fluid">
                                    
                                            <div class="mt-3 px-4 py-3">
                                                <span class="post-meta author text-capitalize text-sm"><i class="ti-user mr-2 text-muted"></i>Admin</span>
                                                <a href=@yield('/show/3')><h5 class="font-secondary mt-2">@yield('title3')</h5></a>
                                            </div>
                                        </article>
                                    </div>
                                </div>
                            </div>
                            
                                <!---------//show 3 more posts using +1------>
                                <!---------pagination for posts using +1 and -1------>
                            <div class="mt-4 border-bottom pb-5">
                                <ul class="list-group list-group-horizontal justify-content-center">
                                    <li class="list-group-item rounded-0 "><a href=@yield('/show/-1') class="text-black"><i class="ti-angle-left mr-3"></i>Previous</a></li>
                                    <li class="list-group-item rounded-0"><a href=@yield('/show/+1') class="text-black">Next <i class="ti-angle-right ml-3"></i></a></li>
                                </ul>
                            </div>
                            
                            </div>  
                            
                        </div>
                    </div>
                    <!--------other side------------>
                    <div class="col-lg-3 col-md-8">
                        <div class="card border-0 rounded-0 mb-5">
                            <form action="#" class="search position-relative">
                                <input type="text" placeholder="Search" class="form-control">
                                <i class="ti-search"></i>
                            </form>
                        </div>
            
                        <div class="mb-5 follow">
                            <h5 class="font-secondary mb-4"><i class="ti-minus mr-2 text-color"></i>Follow us</h5>
                            <!------social media handles------>
                            <a href="#" class="text-muted"><i class="ti-facebook"></i></a>
                            <a href="#" class="text-muted"><i class="ti-twitter"></i></a>
                            <a href="#" class="text-muted"><i class="ti-instagram"></i></a>
                        </div>
            
                        <!------Trending------>
                        <div class="mb-5">
                            <h5 class="font-secondary mb-4"><i class="ti-minus mr-2 text-color"></i>Trending</h5>
                            <!------Trending content------>
                            <div class="media mb-4">
                                <img src="/images/blog/blog-post-5.jpg" alt="" class="img-fluid pr-4 w-50 align-self-center">
                                <div class="media-body">
                                    <a href="#" class="text-black d-block lh-25"> Track your daily body fitness</a>
                                </div>
                            </div>
                        </div>
            
                        <!------Tags------>
                        <div class="mb-5 tags">
                            <h5 class="font-secondary mb-4"><i class="ti-minus mr-2 text-color"></i>Tags</h5>
                            <p href="#">body</p>
                            <p href="#">fitness</p>
                            <p href="#">health</p>
                            <p href="#">diet</p>
                        </div>
            
                    </div>
                </div>
            </div>
    </section>
@endsection