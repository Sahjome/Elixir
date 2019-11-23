<?php
$title = 'Profiles';
$page = 'Member Profiles';
$i=1;
    //Firstname	Surname	Othername				Password
    //							updated_at
//dd($profile);
    ?>

@extends('layout.app')
@section('section')

<section class="section about">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-sm-12 table-responsive">
                <table class="table mt-5 table-hover" style="width: 100%;">
                    <thead>
                        <tr>
                            <th>s/n</th>
                            <th>Surname</th>
                            <th>F.O Names</th>
                            <th>Sex</th>
                            <th>Status</th>
                            <th>Email</th>
                            <th>Phone</th>
                            <th>Address</th>
                            <th>Birthday</th>
                            <th>Life Group</th>
                            <th>Committee</th>
                            <th>Department</th>
                            <th>Graduated</th>
                            <th>Registered</th>
                        </tr>
                    </thead>
                    <tbody>
                        @if(!empty($profile))
                            
                                @foreach ($profile as $item)
                                <tr>
                                    <th>{{$i++}}</th>
                                    <td>{{$item['Surname']}}</td>
                                    <td>{{$item['Firstname'].'.'. $item['Othername']}}</td>
                                    <td>{{$item['Sex']}}</td>
                                    <td>{{$item['Status']}}</td>
                                    <td>{{$item['Email']}}</td>
                                    <td>{{$item['Phone']}}</td>
                                    <td>{{$item['Address']}}</td>
                                    <td>{{$item['DOB']}}</td>
                                    <td>{{$item['Life_Group']}}</td>
                                    <td>{{$item['Committee']}}</td>
                                    <td>{{$item['Dept']}}</td>
                                    <td>{{$item['Grad']}}</td>
                                    <td>{{$item['created_at']}}</td>
                                </tr>
                                @endforeach
                            
                        @else
                            <tr>{{'There are no profiles yet.'}}</tr>
                        @endif
                        
                        
                    </tbody>
                    <tfoot>
                        <tr>
                            <th>s/n</th>
                            <th>Surname</th>
                            <th>First.Other Names</th>
                            <th>Sex</th>
                            <th>Status</th>
                            <th>Email</th>
                            <th>Phone</th>
                            <th>Address</th>
                            <th>Birthday</th>
                            <th>Life Group</th>
                            <th>Committee</th>
                            <th>Department</th>
                            <th>Graduated</th>
                            <th>Registered</th>
                        </tr>
                    </tfoot>
                    
                </table>
        

       
        <div class="row justify-content-center mt-5">
            <nav aria-label="Page navigation ">
                <ul class="pagination justify-content-center">
                    {{$profile->links()}}
                </ul>
            </nav>
        </div>
    </div>

    </div>
    </div>
     
</section>

@endsection