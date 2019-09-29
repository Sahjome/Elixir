<?php
    $title = 'Diets';
    $page = 'Rev up';
    //get from the announcement table everything so we can populate
    //using foreach with pagination at the end of the page
?>
@extends('layout.app')

@section('section')

<!-- Section Blog start -->
<section class="section blog bg-gray">
	<div class="container">
		<div class="row">
			<div class="col-lg-4 col-md-6">
	            <article class="card border-0 rounded-0 mb-4">
		            <img src="images/blog/post1.jpg" alt="" class="img-fluid">

                    <div class="mt-3 px-4 py-3 ">
                        <div class="blog-post-meta text-capitalize mb-2">
                            <span class="post-meta date-meta mr-2">
                            <i class="ti-calendar mr-2"></i>March 25, 2019</span> 

                            <span class="post-meta author"><i class="ti-user mr-2 text-muted"></i>john stain</span>
                        </div>
                        <a href={{''}}><h4 class="mb-3 font-secondary">Make your fitness Boost with us</h4></a>
                            
                        <p class="mb-4">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Rerum, minima.</p>

                        <a href={{''}} class="text-color mb-3 d-block"><i class="ti-minus mr-2"></i> Read More</a>
                    </div>
                </article>
            </div> 

            <div class="col-lg-4 col-md-6">
                <article class="card border-0 rounded-0 mb-4">
                    <img src="images/blog/post2.jpg" alt="" class="img-fluid">

                    <div class="mt-3 px-4 py-3">
                        <div class="blog-post-meta text-capitalize mb-2">
                            <span class="post-meta date-meta mr-2">
                            <i class="ti-calendar mr-2"></i>March 25, 2019</span> 

                            <span class="post-meta author"><i class="ti-user mr-2 text-muted"></i>john stain</span>
                        </div>
                        <a href={{''}}><h4 class="mb-3 font-secondary">Ethernity beauty health diet plan</h4></a>
                            
                        <p class="mb-4">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Rerum, minima.</p>

                        <a href={{''}} class="text-color mb-3 d-block"><i class="ti-minus mr-2"></i> Read More</a>
                    </div>
                </article>
            </div>

            <div class="col-lg-4 col-md-6">
                <article class="card border-0 rounded-0 mb-4">
                    <img src="images/blog/post3.jpg" alt="" class="img-fluid">

                    <div class="mt-3 px-4 py-3">
                        <div class="blog-post-meta text-capitalize mb-2">
                            <span class="post-meta date-meta mr-2">
                            <i class="ti-calendar mr-2"></i>March 25, 2019</span> 

                            <span class="post-meta author"><i class="ti-user mr-2 text-muted"></i>john stain</span>
                        </div>
                        <a href={{''}}><h4 class="mb-3 font-secondary">Ever too late to lose weight?</h4></a>
                            
                        <p class="mb-4">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Rerum, minima.</p>

                        <a href={{''}} class="text-color mb-3 d-block"><i class="ti-minus mr-2"></i> Read More</a>
                    </div>
                </article>
            </div>

            <div class="col-lg-4 col-md-6">
                <article class="card border-0 rounded-0 mb-4 mb-lg-0">
                    <img src="images/blog/post4.jpg" alt="" class="img-fluid">

                    <div class="mt-3 px-4 py-3 ">
                        <div class="blog-post-meta text-capitalize mb-2">
                            <span class="post-meta date-meta mr-2">
                            <i class="ti-calendar mr-2"></i>March 25, 2019</span> 

                            <span class="post-meta author"><i class="ti-user mr-2 text-muted"></i>john stain</span>
                        </div>
                        <a href={{''}}><h4 class="mb-3 font-secondary">Make your fitness Boost with us</h4></a>
                            
                        <p class="mb-4">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Rerum, minima.</p>

                        <a href={{''}} class="text-color mb-3 d-block"><i class="ti-minus mr-2"></i> Read More</a>
                    </div>
                </article>
            </div>

            <div class="col-lg-4 col-md-6">
                <article class="card border-0 rounded-0 mb-4 mb-lg-0">
                    <img src="images/blog/post5.jpg" alt="" class="img-fluid">

                    <div class="mt-3 px-4 py-3">
                        <div class="blog-post-meta text-capitalize mb-2">
                            <span class="post-meta date-meta mr-2">
                            <i class="ti-calendar mr-2"></i>March 25, 2019</span> 

                            <span class="post-meta author"><i class="ti-user mr-2 text-muted"></i>john stain</span>
                        </div>
                        <a href={{''}}><h4 class="mb-3 font-secondary">Ethernity beauty health diet plan</h4></a>
                            
                        <p class="mb-4">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Rerum, minima.</p>

                        <a href={{''}} class="text-color mb-3 d-block"><i class="ti-minus mr-2"></i> Read More</a>
                    </div>
                </article>
            </div>

            <div class="col-lg-4 col-md-6">
                <article class="card border-0 rounded-0 mb-4 mb-lg-0">
                    <img src="images/blog/post6.jpg" alt="" class="img-fluid">

                    <div class="mt-3 px-4 py-3">
                        <div class="blog-post-meta text-capitalize mb-2">
                            <span class="post-meta date-meta mr-2">
                            <i class="ti-calendar mr-2"></i>March 25, 2019</span> 

                            <span class="post-meta author"><i class="ti-user mr-2 text-muted"></i>john stain</span>
                        </div>
                        <a href={{''}}><h4 class="mb-3 font-secondary">Ever too late to lose weight?</h4></a>
                            
                        <p class="mb-4">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Rerum, minima.</p>

                        <a href={{''}} class="text-color mb-3 d-block"><i class="ti-minus mr-2"></i> Read More</a>
                    </div>
                </article>
            </div>

		</div>

        <!---------//pagination here-------->
		<div class="row justify-content-center mt-5">
			<nav aria-label="Page navigation ">
                <ul class="pagination justify-content-center">
                    <li class="page-item"><a class="page-link" href="#">Previous</a></li>
                    <li class="page-item active" aria-current="page"><a class="page-link" href="#">1</a></li>
                    <li class="page-item"><a class="page-link" href="#">2</a></li>
                    <li class="page-item"><a class="page-link" href="#">3</a></li>
                    <li class="page-item"><a class="page-link" href="#">Next</a></li>
                </ul>
            </nav>
		</div>
	</div>
</section>

@endsection