<<<<<<< HEAD
	/* Data SHA1: 9e54d2785b3c64438feefc3c84a1ca2198767b15 */
=======
	/* Data SHA1: e32790789b97e45070878db79e4052a1fe3465b4 */
>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b
	.file	"typemap.mj.inc"

	/* Mapping header */
	.section	.data.mj_typemap,"aw",@progbits
	.type	mj_typemap_header, @object
	.p2align	2
	.global	mj_typemap_header
mj_typemap_header:
	/* version */
	.long	1
	/* entry-count */
<<<<<<< HEAD
	.long	1498
=======
	.long	2360
>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b
	/* entry-length */
	.long	262
	/* value-offset */
	.long	145
	.size	mj_typemap_header, 16

	/* Mapping data */
	.type	mj_typemap, @object
	.global	mj_typemap
mj_typemap:
<<<<<<< HEAD
	.size	mj_typemap, 392477
=======
	.size	mj_typemap, 618321
>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b
	.include	"typemap.mj.inc"
