<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Announcement extends Model
{
    protected $table = 'announcements';

    public $primarykey = 'id';

    public $timestamps = true;
}
