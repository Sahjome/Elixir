<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Announcement;
use Illuminate\Facades\session;
use DB;
class AnnouncementController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function index()
    {
        $ann0 = Announcement::orderBy('updated_at', 'desc')->paginate(6);
        return view('announcement.main')->with('ann0', $ann0);
    }

    /**
     * Show the form for creating a new resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function create()
    {   //check if logged in
        return view('announcement.create');
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
            ($_POST['details']=='')? null: $_POST['details'];
            ($_POST['file']=='')? null: $_POST['file'];
            $anno = new Announcement;
            $anno->title = $_POST['title'];
            $anno->type = $_POST['type'];
            $anno->description = $_POST['description'];
            $anno->details = $_POST['details'];
            $anno->file = $_POST['file'];
            $save = $anno->save();
            if ($save) {
                return redirect('/announcements')->with('success','Announcement created.');    
            }
            else {
                return back()->with('error','Something went wrong.');    
            }
            
        } catch (Exception $ex) {
            return back()->with('error',$ex->get_message());
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
        
        //$ann0 = Announcement::find($id);
        $ann0 = [
            'anno' => Announcement::find($id),
            'ann1' => Announcement::find($id+1),
            'ann2' => Announcement::find($id+2),
            'ann_1' => Announcement::find($id-1)
        ];
        return view('announcement.show')->with($ann0);
    }

    /**
     * Show the form for editing the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function edit($id)
    {
         $anno = Announcement::find($id);
         //dd($anno);
         return view('announcement/edit')->with('anno',$anno);
        
        //$anno = DB::select("spInsert($id)");
        //return response()->json($anno);
        // $ann0 = json($anno);
        // return view('announcement/edit')->with('ann0', $ann0);
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
            ($_POST['details']=='')? null: $_POST['details'];
            ($_POST['file']=='')? null: $_POST['file'];
            $anno = Announcement::find($id);
            //dd($anno);
            $anno->title = $_POST['title'];
            $anno->type = $_POST['type'];
            $anno->description = $_POST['description'];
            $anno->details = $_POST['details'];
            $anno->file = $_POST['file'];
            $save = $anno->update();
            if ($save) {
                \Session::flash('success','Announcement updated.');
                return redirect('/announcements');
                // return redirect('/announcements')->with('success','Announcement updated.');    
            }
            else {
                return back()->with('error','Something went wrong.');    
            }
            
        } catch (Exception $ex) {
            return back()->with('error',$ex->message());
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
            $anno = Announcement::find($id);
            //dd($anno['id']);
            $del = $anno->delete();
            if ($del) {
                \Session::flash('success','Announcement deleted.');
                return redirect('/announcements')->with('success','Announcement deleted.');    
            }
            else {
                return back()->with('error','Something went wrong.');    
            }
        } catch (Exception $ex) {
            return back()->with('error', $ex->message());
        }
    }

    public function diets()
    {
        $lok = DB::select("select * from media where diet !=''");
        dd($lok);
    }
}
