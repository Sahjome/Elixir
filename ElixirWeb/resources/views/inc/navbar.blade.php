
<nav class="navbar navbar-expand-lg navigation fixed-top" id="navbar">
	<div class="container-fluid">
	  <a class="navbar-brand" href={{'/'}}>
	  		<h2 class="text-white text-capitalize"></i>Elixir<span class="text-color">Web</span></h2>
	  </a>

	  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarsid" aria-controls="navbarsid" aria-expanded="false" aria-label="Toggle navigation">
		<span class="ti-view-list"></span>
	  </button>
  
	  <div class="collapse text-center navbar-collapse" id="navbarsid">
		<ul class="navbar-nav mx-auto">
		  <li class="nav-item active">
			<a class="nav-link" href="/">Home <span class="sr-only">(current)</span></a>
		  </li>
		  <li class="nav-item"><a class="nav-link" href={{'/announcements'}}>Specials</a></li>
		  <li class="nav-item"><a class="nav-link"href={{'/media'}}>Media</a></li>
		  <li class="nav-item"><a class="nav-link"href={{'/download'}}>Download</a></li>
		  @if (empty(Session::get('userDetails')))
				<li class="nav-item"><a class="nav-link"href={{'/contact'}}>Contact</a></li>
				<div class="my-md-0 ml-lg-4 mt-4 mt-lg-0 ml-auto text-lg-right mb-3 mb-lg-0">
					<li class="nav-item"><a href={{'/login'}} class="nav-link text-white" data-toggle="modal" 
						data-target="#logInPopUp">LOG IN</a></li>
					{{-- <button class="log-btn" type="button" data-toggle="modal" data-target="#logInPopUp">LOG IN</button> --}}
				</div>
			
			@else(!empty(Session::get('userDetails')))
				<li class="nav-item dropdown">
					<a class="nav-link dropdown-toggle" href="/" id="dropdown03"
					data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">create</a>
					<ul class="dropdown-menu  text-center" aria-labelledby="dropdown03">
						<li><a class="dropdown-item" href={{'announcements/create'}}>New Special</a></li>
						<li><a class="dropdown-item" href={{'/media/create'}}>New Media</a></li>
					</ul>
				</li>

				<div class="my-md-0 ml-lg-4 mt-4 mt-lg-0 ml-auto text-lg-right mb-3 mb-lg-0">
					<li class="nav-item"><a class="nav-link" href={{'/logout'}}>Logout</a></li>
				</div>
			@endif
		   
		</ul>
		  
		{{-- <div class="my-md-0 ml-lg-4 mt-4 mt-lg-0 ml-auto text-lg-right mb-3 mb-lg-0">
			<li class="nav-item"><a class="nav-link"href={{''}}>Login</a></li>
		</div> --}}
	  </div>
	</div>
</nav>
