using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    Vector2Int spawnRangeHorizontal;

    [SerializeField]
    Vector2Int spawnRangeVertical;

    [Range(0.0f, 1.0f)]
    [SerializeField]
    float horizontalBias;

    [Range(0.0f, 1.0f)]
    [SerializeField]
    float staggeredSpawnProbability;

    [SerializeField]
    float leftStartingX;

    [SerializeField]
    float rightStartingX;

    [SerializeField]
    float startingY;

    [Range(0.0f, 1.0f)]
    [SerializeField]
    float rareEnemyProbability;

    [SerializeField]
    float secondsBetweenLittleSpawns;

    [SerializeField]
    EnemyPool normalEnemy;

    [SerializeField]
    EnemyPool rareEnemy;

    [SerializeField]
    List<ColorSO> colors;


    [SerializeField]
    AnimationCurve secondsBetweenBigSpawns;

    float elapsed;

    float progress;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (NoEnemies() || elapsed >= secondsBetweenBigSpawns.Evaluate(progress))
        {
            elapsed = 0;
            DetermineSpawn();
        }
    }


    bool NoEnemies()
    {
        return normalEnemy.GetNumActiveObjects() + rareEnemy.GetNumActiveObjects() == 0;
    }

    public void UpdateProgress(float progress)
    {
        this.progress = progress;
    }

    void DetermineSpawn()
    {
        bool changeColor = ExtensionMethods.CoinFlip();
        bool horizontal = ExtensionMethods.CoinFlip(horizontalBias);
        bool allSpawn = !ExtensionMethods.CoinFlip(staggeredSpawnProbability);

        StartCoroutine(StaggeredSpawn(horizontal, changeColor, !allSpawn ? secondsBetweenLittleSpawns : 0));

    }

    IEnumerator StaggeredSpawn(bool horizontal, bool changeColor, float secondsBetweenSpawns)
    {
        List<int> spawnInts = new List<int>();
        for (int i = horizontal ? spawnRangeHorizontal.x : spawnRangeVertical.x; i < (horizontal ? spawnRangeHorizontal.y : spawnRangeVertical.y); i++)
        {
            spawnInts.Add(i);
        }
        spawnInts.Randomize();
        if (secondsBetweenSpawns == 0)
        {
            List<int> half = new List<int>();
            for (int i = 0; i < (int)(spawnInts.Count * 0.75f); i++)
            {
                half.Add(spawnInts[i]);
            }
            spawnInts = half;
        }

        if (!horizontal)
        {
            float x = ExtensionMethods.CoinFlip() ? leftStartingX : rightStartingX;
        }
        ColorSO chosenColor = colors.GetRandomItem();
        bool left = ExtensionMethods.CoinFlip();

        foreach (var spot in spawnInts)
        {
            Vector3 pos = new Vector3();
            if (horizontal)
            {
                pos.y = startingY;
                pos.x = spot;
            }
            else
            {
                pos.x = left ? leftStartingX : rightStartingX;
                pos.y = spot;
            }

            SpawnEnemy(pos, ExtensionMethods.CoinFlip(rareEnemyProbability) ? rareEnemy : normalEnemy, changeColor ? colors.GetRandomItem() : chosenColor, horizontal);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    void SpawnEnemy(Vector3 pos, EnemyPool pool, ColorSO color, bool horizontal)
    {
        var enemy = pool.GetObject();
        enemy.StartingColor = color;
        enemy.transform.position = pos;
        enemy.HorizontalMovement = !horizontal;
        enemy.gameObject.SetActive(true);
    }
}
