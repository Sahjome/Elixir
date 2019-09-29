<?php 
    $title = 'Contact';
    $page = 'Contact us';
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
                    <h2>Contact CLF</h2>
                    <p class="mt-3">Lorem ipsum dolor sit amet, consectetur adipisicing elit. In error reprehenderit quam enim obcaecati, repudiandae officia a cumque nemo provident!</p>
                </div>
            </div>
        </div>

         <div class="row justify-content-center pb-5">
            <div class="col-lg-9 text-center">
                <form id="contact-form">
                    <div class="form-row">
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div class="form-group">
                                <input name="user_name" type="text" class="form-control" placeholder="Your Name">
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div class="form-group">
                                <input name="user_email" type="text" class="form-control" placeholder="Email Address">
                            </div>
                        </div>
                       
                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <div class="form-group-2">
                                <textarea name="user_message" class="form-control" rows="8" placeholder="Your Message"></textarea>
                            </div>

                            <div class="text-center">
                                <button class="btn btn-main mt-3" type="submit">Send Message</button>
                            </div>
                        </div>
                    </div>
                     <div class="error" id="error">Sorry Msg dose not sent</div>
                    <div class="success" id="success">Message Sent</div>
                </form>
            </div>
        </div>
    </div>
    <div class="google-map position-relative mt-5">
            <div id="map"></div>
    </div>
    
    <div class="container mt--170">
        <div class="row">
            <div class="col-lg-4 col-md-6 mb-4 mb-lg-0">
                <div class="card rounded-0 border-0 shadow-sm text-center py-5 px-4 contact-info">
                    <i class="ti-mobile mb-3 text-lg text-color"></i>
                    <span>Call us</span>
                    <p class="lead text-black mb-0 mt-3">++234 (0) 907–587-3424</p>
                    <p class="lead">9:00 am - 17:00 pm W.A.T</p>
                </div>
            </div>
            <div class="col-lg-4 col-md-6 mb-4 mb-lg-0">
                <div class="card rounded-0 border-0 shadow-sm text-center py-5 px-4 contact-info">
                    <i class="ti-email mb-3 text-lg text-color"></i>
                    <span>Email</span>
                    <p class="lead text-black mt-3 mb-0">clfoau@gmail.com</p>
                </div>
            </div>
            <div class="col-lg-4 col-md-6 mb-4 mb-lg-0">
                <div class="card rounded-0 border-0 shadow-sm text-center py-5 px-4 contact-info">
                    <i class="ti-home mb-3 text-lg text-color"></i>
                    <span>Location</span>
                    <p class="lead text-black mt-3">{{"Beside RCCG Kings' court, Religious ground, OAU, Ile-ife, Osun state, Nigeria."}}</p>
                </div>
            </div>
        </div>
    </div>
</section>
<section class="contact-form section">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-lg-8 text-center">
                <div class="section-title">
                    <div class="divider mb-3"></div>
                    <h2>what we believe</h2>
                </div>
            </div>
        </div>
        <div class="container ">
            <div class="row">
                <div class="col-lg-4 col-md-6 mb-4 mb-lg-0">
                    <div class="card rounded-0 border-0 shadow-sm text-center py-5 px-4 contact-info">
                        <i class="ti-mobile mb-3 text-lg text-color"></i>
                        <span>Wednesdays</span>
                        <p class="lead text-black mt-3 mb-0">6:00 pm - 8:30 pm W.A.T</p>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6 mb-4 mb-lg-0">
                    <div class="card rounded-0 border-0 shadow-sm text-center py-5 px-4 contact-info">
                        <i class="ti-email mb-3 text-lg text-color"></i>
                        <span>Sundays</span>
                        <p class="lead text-black mt-3 mb-0">9:00 am - 11:00 am W.A.T</p>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6 mb-4 mb-lg-0">
                    <div class="card rounded-0 border-0 shadow-sm text-center py-5 px-4 contact-info">
                        <i class="ti-home mb-3 text-lg text-color"></i>
                        <span>Vigils</span>
                        <p class="lead text-black mt-3 mb-0">11:00 pm - 3:30 am W.A.T</p>
                        <p class="lead">every last friday of the month</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
@endsection