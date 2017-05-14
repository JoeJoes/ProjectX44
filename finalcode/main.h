typedef enum znak {z0 = 0x00,
			 z1 = 0x01,
			 z2 = 0x02,
			 z3 = 0x03,
			 z4 = 0x04,
			 z5 = 0x05,
			 z6 = 0x06,
			 z7 = 0x07,
			 z8 = 0x08,
			 z9 = 0x09,
			 zA = 0x0a,
			 zB = 0x0b,
			 zC = 0x0c,
			 zD = 0x0d,
			 zE = 0x0e,
			 zF = 0x0f,
			 zG = 0x10,
			 zH = 0x11,
			 zJ = 0x12,
			 zL = 0x13,
			 zM = 0x14,
			 zN = 0x15,
			 zP = 0x16,
			 zR = 0x17,
			 zT = 0x18,
			 zU = 0x19,
			 zY = 0x1a,
			 zCIR = 0x1b,
			 zDOT = 0x1c,
			 zUSC = 0x1d,
			 zDSH = 0x1e,
			 zQMK = 0x1f,};

const int MSG1[] = {zT,zE,z5,zT};
const int MSG2[] = {zH,zA,zP,zA};
const int MODE[] = {zM,z0,zD,zE};
const int DOWN[] = {zD,z0,zU,zN};
const int UP[]   = {zDSH,zU,zP,zDSH};
const int SET[]  = {z5,zE,zT,zDSH};