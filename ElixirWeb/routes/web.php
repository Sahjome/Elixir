<?php
use Illuminate\Http\Request;
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

//Route::get('/reply', 'PagesController@reply');

Route::get('/', 'PagesController@index');
//Route::get('/show', 'PagesController@show');
Route::get('/about', 'PagesController@about');
Route::get('/contact', 'PagesController@contact');
//Route::get('/special', 'PagesController@special');
Route::get('/download', 'PagesController@download');
Route::any('/messages', 'PagesController@Message');
Route::any('/counselling/{username}', 'PagesController@Password');
//Route::get('/diet/show/{id}', 'MediaController@showDiet');
Route::get('/announcements', 'AnnouncementController@index');
Route::get('/announcements/show/{id}', 'AnnouncementController@show');
Route::get('/media/show/{id}', 'MediaController@show');
Route::get('/media','MediaController@index');
//Route::get('/add', 'PagesController@add');
//Route::get('/login','Auth\LoginController@redirectTo');
Route::get('/login','LoginController@index');
Route::get('/see/{pass}/{entry}','LoginController@users');
Route::post('/mail/{email}','MailController@send');
Route::any('/send', 'PagesController@CreateReply');

//only admin access
Route::group(['middleware' => 'test'], function () {
    Route::get('/announcements/edit/{id}', 'AnnouncementController@edit');
    Route::get('/announcements/create', 'AnnouncementController@create');
    Route::any('/saveA', 'AnnouncementController@store');
    Route::get('/profiles', 'PagesController@profiles');
    Route::any('/editA/{id}', 'AnnouncementController@update');
    Route::get('/media/create','MediaController@create');
    Route::any('/delA/{id}', 'AnnouncementController@destroy');
    Route::any('/saveM', 'MediaController@store');
    Route::get('/media/edit/{id}', 'MediaController@edit');
    Route::any('/editM/{id}', 'MediaController@update');
    Route::any('/delM/{id}', 'MediaController@destroy');
    Route::get('/logout', 'LoginController@logout');
    Route::any('/reply', 'PagesController@reply')->middleware('reply');
    //Route::get('/profiles', 'PagesController@profiles');
});
Route::get('welcome', function (Request $request)
{
    $uri = $request->path();
    return view('inc.username')->with('uri',$uri);
});
Route::any('/password','PagesController@Hasher');
