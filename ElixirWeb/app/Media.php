<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Media extends Model
{
    protected $table = 'media';
    public $primaryKey = 'id';
    public $timestamp = 'true';
    public $fillable = ['title','type','description','file','image','diet'];
}
