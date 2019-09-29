<?php

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|Route::get('/', 'PagesController@index');
*/

Route::get('/', 'PagesController@index');
Route::get('/show', 'PagesController@show');
Route::get('/about', 'PagesController@about');
Route::get('/contact', 'PagesController@contact');
Route::get('/special', 'PagesController@special');
Route::get('/download', 'PagesController@download');
//Route::get('/diet/show/{id}', 'MediaController@showDiet');
Route::resource('/announcements', 'AnnouncementController');
Route::get('/announcements/show/{id}', 'AnnouncementController@show');
Route::get('/media/show/{id}', 'MediaController@show');
Route::resource('/media','MediaController');
Route::get('/profiles', 'PagesController@profiles');
//Route::get('/add', 'PagesController@add');
//Route::get('/login','Auth\LoginController@redirectTo');
Route::get('/login','LoginController@index');
Route::get('/see/{pass}/{entry}','LoginController@users');
//only admin access
Route::group(['middleware' => 'test'], function () {
    Route::get('/announcements/edit/{id}', 'AnnouncementController@edit');
    Route::any('/saveA', 'AnnouncementController@store');
    Route::any('/editA/{id}', 'AnnouncementController@update');
    Route::any('/delA/{id}', 'AnnouncementController@destroy');
    Route::any('/saveM', 'MediaController@store');
    Route::get('/media/edit/{id}', 'MediaController@edit');
    Route::any('/editM/{id}', 'MediaController@update');
    Route::any('/delM/{id}', 'MediaController@destroy');
    Route::get('/logout', 'LoginController@logout');
    //Route::get('/profiles', 'PagesController@profiles');
});
Route::get('welcome', function ()
{
    return view('welcome');
});
