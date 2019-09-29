<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Media;
use DB;

class MediaController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function index()
    {
        $ann0 = Media::orderBy('updated_at','desc')->paginate(6);
        return view('media.main')->with('ann0',$ann0);
        
    }

    /**
     * Show the form for creating a new resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function create()
    {
        return view('media.create');
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return \Illuminate\Http\Response
     */
    public function store(Request $request)
    {
        try {
            $ann0 = new Media();
            $ann0->title = $_POST['title'];
            $ann0->type = $_POST['type'];
            $ann0->description = $_POST['description'];
            $ann0->file = $_POST['file'];
            //$ann0->diet = $_POST['diet'];
            $ann0->image = $_POST['image'];
            $save = $ann0->save();
            if($save){
                return redirect('/media')->with('success', 'Media content successfully created.');
            } 
                return back()->with('error','Media content created failed to create.');
        } catch (Exception $ex) {
            //throw $th;
            return back()->with('error','Media content created failed to create.'.$ex->getMessage());
        }
        
    }

    /**
     * Display the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function show($id)
    {
        
        try {
            $ann0 = [
                'anno' => Media::find($id),
                'ann1' => Media::find($id+1),
                'ann2' => Media::find($id+2),
                'ann_1' => Media::find($id-1)
            ];
            return view('media.show')->with($ann0);
        } catch (\Throwable $th) {
            throw $th;
        }
        
    }

    /**
     * Show the form for editing the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function edit($id)
    {
        $ann0 = Media::find($id);
        return view('media.edit')->with('ann0',$ann0);
    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function update(Request $request, $id)
    {
        try {
            $ann0 = Media::find($id);
            $ann0->title = $_POST['title'];
            $ann0->type = $_POST['type'];
            $ann0->description = $_POST['description'];
            $ann0->file = $_POST['file'];
            //$ann0->diet = $_POST['diet'];
            $ann0->image = $_POST['image'];
            $update = $ann0->update();
            if($update){
                return redirect('/media')->with('success', 'Media content successfully updated.');
            } 
                return back()->with('error','Media content created failed to update.');
        } catch (Exception $ex) {
            //throw $th;
            return back()->with('error','Media content created failed to update.'.$ex->getMessage());
        }
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function destroy($id)
    {
        try {
            $ann0 = Media::find($id);
            //dd($ann0['id']);
            $delete = $ann0->delete();
            if($delete){
                return redirect('/media')->with('success', 'Media content successfully deleted.');
            } 
                return back()->with('error','Media content failed to delete.');
        } catch (Exception $ex) {
            return back()->with('error','Media content failed to delete.'.$ex->getMessage());
        }
    }

    //<!------------------DIET------------------->
    //all diet in media
    // public function diets()
    // {
    //     $ann0 = Media::where('diet','!=', '')->paginate(6);
    //     //dd($ann0);
    //     return view('diet.main')->with('ann0',$ann0);
    // }

    // //show diet/id
    // public function showDiet($id){
    //     dd($id);
    //     $ann0 = Media::find($id);

    // }
}
