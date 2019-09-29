<!DOCTYPE html>
<html lang="{{ str_replace('_', '-', app()->getLocale()) }}">
    <head>
        <!-- Required meta tags -->
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
            
        <title>{{config('app_name', 'Elixir|'.$title)}}</title>
        

        <!-- bootstrap.min css -->
        <link rel="stylesheet" href="/plugins/bootstrap/css/bootstrap.min.css">
        <!-- Icofont Css -->
        <link rel="stylesheet" href="/plugins/icofont/icofont.min.css">
        <!-- Themify Css -->
        <link rel="stylesheet" href="/plugins/themify/css/themify-icons.css">
        <!-- animate.css -->
        <link rel="stylesheet" href="/plugins/animate-css/animate.css">
        <!-- Magnify Popup -->
        <link rel="stylesheet" href="/plugins/magnific-popup/dist/magnific-popup.css">
        <!-- Owl Carousel CSS -->
        <link rel="stylesheet" href="/plugins/slick-carousel/slick/slick.css">
        <link rel="stylesheet" href="/plugins/slick-carousel/slick/slick-theme.css">
        <!-- Main Stylesheet -->
        <link rel="stylesheet" href={{('/css/style.css')}}>
        <!-- Fonts -->
        <link href="https://fonts.googleapis.com/css?family=Nunito:200,600" rel="stylesheet">

    </head>

    <body>
        @include('inc.navbar')
        
        <div class="main-wrapper">
            @include('inc.message')
            @include('inc.header')
            @include('inc.login')
            @yield('section')
            @include('inc.footer')
        </div>
    
        <!-- Essential Scripts=====================================-->
        
        <!-- Main jQuery -->
        <script src="/plugins/jquery/jquery.js"></script>
        <!-- Bootstrap 4.3.1 -->
        <script src="/plugins/bootstrap/js/bootstrap.min.js"></script>
        <!-- Slick Slider -->
        <script src="/plugins/slick-carousel/slick/slick.min.js"></script>
        <!--  Magnific Popup-->
        <script src="/plugins/magnific-popup/dist/jquery.magnific-popup.min.js"></script>
        <!-- Form Validator -->
        <script src="/../../cdnjs.cloudflare.com/ajax/libs/jquery.form/3.32/jquery.form.js"></script>
        <script src="/../../cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.11.1/jquery.validate.min.js"></script>
        <!-- Google Map -->
        <script src="/plugins/google-map/map.js"></script>
        <script src="/https://maps.googleapis.com/maps/api/js?key=AIzaSyAkeLMlsiwzp6b3Gnaxd86lvakimwGA6UA&amp;callback=initMap"></script>    
        <script src="/js/script.js"></script>
        <script src="/vendor/vendor/ckeditor/ckeditor.js"></script>
        <script>
            CKEDITOR.replace('summary-ckeditor');
        </script>
        <script src="asset/./node_modules/ckeditor/ckeditor.js"></script>
        <script>
            CKEDITOR.replace( 'editor' );
        </script>
    </body>
    
</html>
