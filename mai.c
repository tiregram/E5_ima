
int cont(int* t ,int n, int s )
{
  int p=0;
  for (int i = 1; i < n ; i++) {
    for (int j = 0; j < s ; j++) {
      while(t[p] == 0)
        p = (p+1)%n;
    }
    t[p] = 0;
  }

  while(t[p] == 0)
    p = (p+1)%n;

  return p;
}

int cont2(int* t ,int n, int s )
{
  int p=0;
  for (int i = 0; i < s*(n-1) ; i++) {
    t[p]=(i%s==0)?0:1;
    while(t[p] == 0)
        p = (p+1)%n;
  }

  return p;
  }
#include <stdio.h>
int main(int argc, char *argv[])
{
  int e[] = {1,1,1,1,1,1,1,1,1,1,1,1,1};
  printf("%d\n",cont(e,13,4));

  int e1[] = {1,1,1,1,1,1,1,1,1,1,1,1,1};
  printf("%d\n",cont2(e1,3,4));

  return 0;
}
