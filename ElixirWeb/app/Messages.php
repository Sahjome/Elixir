<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Messages extends Model
{
    protected  $table = 'direct_message';
    public $primaryKey = 'id';
    public $timestamps = true;

}
