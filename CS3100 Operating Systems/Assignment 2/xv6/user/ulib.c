#include "kernel/types.h"
#include "kernel/stat.h"
#include "kernel/fcntl.h"
#include "user/user.h"

//
// wrapper so that it's OK if main() does not call exit().
//
void _main() {
	extern int main();
	main();
	exit(0);
}

char* strcpy(char *s, const char *t) {
	char *os;

	os = s;
	while((*s++ = *t++) != 0)
		;
	return os;
}

int strcmp(const char *p, const char *q) {
	while(*p && *p == *q)
		p++, q++;
	return (uchar)*p - (uchar)*q;
}

uint strlen(const char *s) {
	int n;

	for(n = 0; s[n]; n++)
		;
	return n;
}

void* memset(void *dst, int c, uint n) {
	char *cdst = (char *) dst;
	int i;
	for(i = 0; i < n; i++) {
		cdst[i] = c;
	}
	return dst;
}

char* strchr(const char *s, char c) {
	for(; *s; s++)
		if(*s == c)
			return (char*)s;
	return 0;
}

char* gets(char *buf, int max) {
	int i, cc;
	char c;

	for(i=0; i+1 < max; ) {
		cc = read(0, &c, 1);
		if(cc < 1)
			break;
		buf[i++] = c;
		if(c == '\n' || c == '\r')
			break;
	}
	buf[i] = '\0';
	return buf;
}

int stat(const char *n, struct stat *st) {
	int fd;
	int r;

	fd = open(n, O_RDONLY);
	if(fd < 0)
		return -1;
	r = fstat(fd, st);
	close(fd);
	return r;
}

int atoi(const char *s) {
	int n;

	n = 0;
	while('0' <= *s && *s <= '9')
		n = n*10 + *s++ - '0';
	return n;
}

char * itoa(int num) {
// This function converts a positive or negative decimal integer to ASCII
	static char str[20]; // return string, static = not on the stack
	int i = 0;           // index for string when adding digits
	int start, end;      // used to reverse the digits;
	int isneg = (num < 0); // integer (boolean) indicating num is negative
	char tmpchar;        // temp variable used to swap characters

	if (num == 0) { // zero is a special case
		str[i++] = '0'; // set string to "0"
		str[i] = '\0'; // NULL terminate string
		return str; // return with the string, "0"
	}     // None of the rest executes for zero

	while (num != 0) { // not zero, convert each digit
		str[i++] = (num % 10) + '0'; // add ASCII char in reverse order
		num = num / 10; // go to next digit
	}

	if (isneg) str[i++] = '-'; // if negative add the minus sign
	str[i] = '\0'; // NULL terminate the string

	// now reverse the string
	start = 0; // initialize start and end to the first and last ASCII
	end = i - 1; // character positions (not the NULL)
	while (start < end) { // swap the char at end with the one at start
		tmpchar = str[start];
		str[start] = str[end];
		str[end] = tmpchar;
		start++;
		end--;
	}
	return str;
}

void* memmove(void *vdst, const void *vsrc, int n) {
	char *dst;
	const char *src;

	dst = vdst;
	src = vsrc;
	if (src > dst) {
		while(n-- > 0)
			*dst++ = *src++;
	} else {
		dst += n;
		src += n;
		while(n-- > 0)
			*--dst = *--src;
	}
	return vdst;
}

int memcmp(const void *s1, const void *s2, uint n) {
	const char *p1 = s1, *p2 = s2;
	while (n-- > 0) {
		if (*p1 != *p2) {
			return *p1 - *p2;
		}
		p1++;
		p2++;
	}
	return 0;
}

void * memcpy(void *dst, const void *src, uint n) {
	return memmove(dst, src, n);
}
