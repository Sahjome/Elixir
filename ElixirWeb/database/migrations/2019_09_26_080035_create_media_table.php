<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateMediaTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('media', function (Blueprint $table) {
            $table->bigIncrements('id');
            $table->string('title');//title or name
            $table->string('type');//diet(text only),content
            $table->string('description');
            $table->text('diet')->nullable();
            $table->string('file')->nullable();//video,pdf,audio,text
            $table->string('image')->default('\images\blog\post-1.jpg');//featured image
            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('media');
    }
}
