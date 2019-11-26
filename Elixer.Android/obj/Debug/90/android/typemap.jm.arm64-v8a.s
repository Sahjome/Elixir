<<<<<<< HEAD
	/* Data SHA1: 430c22eaa352a99a61e44d60b48c72e4b9ede347 */
=======
	/* Data SHA1: 0240d05a082ec792666b2f69ad068cbd532530df */
>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b
	.arch	armv8-a
	.file	"typemap.jm.inc"

	/* Mapping header */
	.section	.data.jm_typemap,"aw",@progbits
	.type	jm_typemap_header, @object
	.p2align	2
	.global	jm_typemap_header
jm_typemap_header:
	/* version */
	.word	1
	/* entry-count */
<<<<<<< HEAD
	.word	1350
=======
	.word	2123
>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b
	/* entry-length */
	.word	262
	/* value-offset */
	.word	117
	.size	jm_typemap_header, 16

	/* Mapping data */
	.type	jm_typemap, @object
	.global	jm_typemap
jm_typemap:
<<<<<<< HEAD
	.size	jm_typemap, 353701
=======
	.size	jm_typemap, 556227
>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b
	.include	"typemap.jm.inc"
