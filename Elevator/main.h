const int NUM[][3] = {{0,0,0}, //0
		      {0,0,1}, //1
		      {0,1,0}, //2
		      {0,1,1}, //3
		      {1,0,0}, //4
		      {1,0,1}, //5
		      {1,1,0}, //6
		      {1,1,1}};//7

int cur_floor = 0;
int floors = 4;
int MS = 0; //0=up, 1=down
int temp;
int is_moving = 0;
int alt = 0;


void bcd(int num) //funguje yay
{
	for(int i = 0; i<3; i++) setPin(5+i,1 ^ (NUM[num][i]));
	portWrite();
}


int find_floor() //taky funguje
{
	for(int i = 1; i <= floors; i++)
	{
		if(readPin(7+i)) return i;
	}
	return 0;
}

void display() //shows direction, floor and actualize cur_floor
{
	portRead();
	if(is_moving)
	{
		setPin(3+MS, 1);
		setPin(4-MS, 0);
	}
	else
	{
		setPin(3, 0);
		setPin(4, 0);
	}
	temp = find_floor();
	if(temp!=0) cur_floor = temp;
	bcd(cur_floor);
}