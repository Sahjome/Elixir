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
        <div class="row float-left">
            <div class="col-6">
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th scope="col">s/n</th>
                            <th scope="col">Surname</th>
                            <th scope="col">F.O Names</th>
                            <th scope="col">Sex</th>
                            <th scope="col">Status</th>
                            <th scope="col">Email</th>
                            <th scope="col">Phone</th>
                            <th scope="col">Address</th>
                            <th scope="col">Birthday</th>
                            <th scope="col">Committee</th>
                            <th scope="col">Department</th>
                            <th scope="col">Graduated</th>
                            <th scope="col">Registered</th>
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
                            <th scope="col">s/n</th>
                            <th scope="col">Surname</th>
                            <th scope="col">First.Other Names</th>
                            <th scope="col">Sex</th>
                            <th scope="col">Status</th>
                            <th scope="col">Email</th>
                            <th scope="col">Phone</th>
                            <th scope="col">Address</th>
                            <th scope="col">Birthday</th>
                            <th scope="col">Committee</th>
                            <th scope="col">Department</th>
                            <th scope="col">Graduated</th>
                            <th scope="col">Registered</th>
                        </tr>
                    </tfoot>
                    
                </table>
            </div>
        

        </div>
        <div class="row justify-content-center mt-5">
            <nav aria-label="Page navigation ">
                <ul class="pagination justify-content-center">
                    {{$profile->links()}}
                </ul>
            </nav>
        </div>
    </div>
     
</section>

@endsection