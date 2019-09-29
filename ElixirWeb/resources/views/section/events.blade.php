<?php
//gget all the uploaded events from the db- from announcement table type-event
//and use a foreach to make the latest 8 of them appear
use App\Announcement;
$ann = Announcement::orderBy('updated_at','desc')->get();
//dd($ann);

//dd($ann0);
?>

<!-- Section Course Start -->
@if (count($ann)>3)
<section class="section course bg-gray">
	<div class="container">
		<div class="row justify-content-center">
			<div class="col-lg-8 text-center">
				<div class="section-title">
					<div class="divider mb-3"></div>
					<h2>Recent Specials</h2>
					<p>We offer more than 35 group exercis, aerobic classes each week.</p>
				</div>
			</div>
		</div>

		<div class="row">
			
				$ann0 = [$ann[0],$ann[1],$ann[2],$ann[3]];
				@foreach ($ann0 as $item)
				
					<div class="col-lg-3 col-md-6">
						<div class="card border-0 rounded-0 p-0 mb-5 mb-lg-0 shadow-sm">
							<img src={{$item->file}} alt="" class="img-fluid">

							<div class="card-body">
								<a href={{'/announcements/show/'.$item->id}}><h4 class="font-secondary mb-0">{{$item->title}}</h4></a>
								<p class="mb-2">Author: Admin</p>
							</div>
						</div>
					</div>
					
				@endforeach
			
			
			

			

		</div>
		<div class="row justify-content-center">
			<div class="col-lg-8">
				<div class="mt-5 text-center">
					<a href={{'/announcements'}} class="btn btn-main">See all Specials</a>
				</div>
			</div>
		</div>
	</div>
</section>
<!-- Section Course ENd -->
@endif