using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Block : MonoBehaviour
{
    public GameObject block;
    public GameObject player;


    static public List<GameObject> blocks_upper_left = new();
    static public List<GameObject> blocks_lower_left = new();
    static public List<GameObject> blocks_upper_right = new();
    static public List<GameObject> blocks_lower_right = new();
    static public List<GameObject> blocks_upper_row = new();
    

    public List<int> pepe = new();

    public int BlockNum = 0;
    public int b_num;

    public List<int> nums = new();
    public Building[] builds;

    // Booleans for creation of blocks
    public bool init = true;

    // New wall coords for index: 0 -> x, 1 ->y , 2-> z
    public List<float> pos = new();

    // In terms of instantiate the blocks? Create a 3x3 initial instantiation.
    // Create invisible barriers, ex. go right, if crossed x = 500, then get that wall x = 500 +100, instantiate new right.
    // get x = 500 + 500, and do up = x = 1000, z = ???

    // Use this for initialization
    void Start()
    {

        // Get reference to player for positioning
        player = GameObject.Find("Player");
        //Get first block_number
        b_num = block.GetComponentInChildren<Building>().BlockNum;
        nums.Add(b_num);

        // Create constante X and Z positions.
        int const_posX = 1000;
        int neg_const_posX = -999;
        int const_posY = 473;
        int neg_const_posY = -421;

        /*
         * Instantiate by quadrants (21+12+4+20+1
         */

        // Instantiate Right Upper Quadrant (21 blocks) and add to blocks_upper_right for procedure.
        for (int i = 1; i<5; i++)
        {
            Vector3 pos_right = new Vector3(const_posX, 0, 26);
            GameObject right_block = Instantiate(block, pos_right, Quaternion.identity);
            set_block_num(right_block);
            for (int j = 1; j < 5; j++)
            {
                Vector3 pos_up = new Vector3(const_posX, 0, const_posY);
                GameObject upper_block = Instantiate(block, pos_up, Quaternion.identity);
                set_block_num(upper_block);
                const_posY += 447;
                blocks_upper_right.Add(upper_block);
            }
            const_posX += 1000;
            const_posY = 473;
            blocks_upper_right.Add(right_block);
        }

        // Set all Upper Quadrant blocks false
        for (int i = 0; i < blocks_upper_right.Count; i++)
        {
            blocks_upper_right[i].SetActive(false);

        }

        // Instantiate Left Upper Quadrant (12 blocks)
        for (int i = 1; i < 4; i++)
        {
            Vector3 pos_left = new Vector3(neg_const_posX, 0, 26);
            GameObject left_block = Instantiate(block, pos_left, Quaternion.identity);
            set_block_num(left_block);
            for (int j = 1; j < 5; j++)
            {
                Vector3 pos_up = new Vector3(neg_const_posX, 0, const_posY);
                GameObject lower_block = Instantiate(block, pos_up, Quaternion.identity);
                set_block_num(lower_block);
                blocks_upper_left.Add(lower_block);
                const_posY += 447;
            }
            neg_const_posX -= 999;
            const_posY = 473;
            blocks_upper_left.Add(left_block);
        }

        // Set all Left Upper Quadrant blocks false
        for (int i = 0; i < blocks_upper_left.Count; i++)
        {
            blocks_upper_left[i].SetActive(false);

        }


        // Instantiate Upper Block Row (4 blocks)
        for (int i = 1; i < 5; i++)
        {
            Vector3 pos_up = new Vector3(0, 0, const_posY);
            GameObject upper_block = Instantiate(block, pos_up, Quaternion.identity);
            set_block_num(upper_block);

            const_posY += 447;
            blocks_upper_row.Add(upper_block);
            
        }

        // Set all Upper Indv row false
        for (int i = 0; i < blocks_upper_row.Count; i++)
        {
            blocks_upper_row[i].SetActive(false);

        }

        const_posX = 1000;
        //Instantiate Lower Right Quadrant Blocks (20)
        for (int i = 1; i < 5; i++)
        {
            Vector3 pos_low = new Vector3(0, 0, neg_const_posY);
            GameObject lower_block = Instantiate(block, pos_low, Quaternion.identity);
            set_block_num(lower_block);
            for (int j = 1; j < 5; i++)
            {
                Vector3 pos_right = new Vector3(const_posX, 0, neg_const_posY);
                GameObject right_block = Instantiate(block, pos_right, Quaternion.identity);
                set_block_num(right_block);
                blocks_lower_right.Add(right_block);
                right_block.SetActive(false);
                const_posX += 1000;
            }
            const_posX = 1000;
            neg_const_posY -= 421;
            blocks_lower_right.Add(lower_block);
            lower_block.SetActive(false);
        }
        //// Set all Lower Right Quadrant Blocks
        //for (int i = 0; i < blocks_lower_right.Count; i++)
        //{
        //    blocks_lower_right[i].SetActive(false);

        //}

    }


    IEnumerator CheckPosition()
    {
        if (init)
        {
            init = false;
            yield return new WaitForSeconds(0.1f);
            
        }
        else
        {
            yield return new WaitForSeconds(4);
        }

        float current_pos_x;
        float current_pos_z;

        // Set all Upper Indv row true or false by proximity
        for (int i = 0; i < blocks_upper_row.Count; i++)
        {
            
            current_pos_z = Mathf.Abs(player.transform.position.z - blocks_upper_row[i].transform.position.z);
            current_pos_x = Mathf.Abs(player.transform.position.z - blocks_upper_row[i].transform.position.x);

            // Check player proximity
            if (Mathf.Sqrt(current_pos_x*current_pos_x + current_pos_z* current_pos_z) < 1000)
            {
                blocks_upper_row[i].SetActive(true);
            }
        }

        // Set all Upper Right Quadrant true or false by proximity
        for (int i = 0; i < blocks_upper_right.Count; i++)
        {

            current_pos_z = Mathf.Abs(player.transform.position.z - blocks_upper_right[i].transform.position.z);
            current_pos_x = Mathf.Abs(player.transform.position.z - blocks_upper_right[i].transform.position.x);

            // Check player proximity
            if (Mathf.Sqrt(current_pos_x * current_pos_x + current_pos_z * current_pos_z) < 1000)
            {
                blocks_upper_right[i].SetActive(true);
            }
        }

        // Set all Upper Right Quadrant true or false by proximity
        for (int i = 0; i < blocks_lower_right.Count; i++)
        {

            current_pos_z = Mathf.Abs(player.transform.position.z - blocks_lower_right[i].transform.position.z);
            current_pos_x = Mathf.Abs(player.transform.position.z - blocks_lower_right[i].transform.position.x);

            // Check player proximity
            if (Mathf.Sqrt(current_pos_x * current_pos_x + current_pos_z * current_pos_z) < 1000)
            {
                blocks_lower_right[i].SetActive(true);
            }
        }


    }

    // Update is called once per frame
    // Here we want them to dissapear, and to appear on range of visibility
    void Update()
    {

        StartCoroutine(CheckPosition());

    }

    // Set new Block Numbers for newly generated blocks
    private void set_block_num(GameObject parent)
    {
        // Get last block number assigned
        int last;
        int new_b;
        last = nums[^1];

        if (last == 69){
            // set bool no more creation -> True;
            return;
        }

        // Increment and set for each building the BlockNum associated.
        new_b = last + 1;
        nums.Add(new_b);

        builds = parent.GetComponentsInChildren<Building>();
        foreach (Building building in builds)
        {
            building.BlockNum = new_b;
            //Debug.Log("All new blocks are num " + yourScript.BlockNum);
        }

    }

}
