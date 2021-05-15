using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private List<AnimationDetails> _animationList;

    private int _totalWeight;
    System.Random _random;
    
    // Start is called before the first frame update
    void Start()
    {
        _random = new System.Random();
        _totalWeight = GetTotalWeight();
        PlayAnimationState();
    }

    private void PlayAnimationState() {
        int randomValue = _random.Next(0, _totalWeight); 
        Debug.Log("Random:" + randomValue);

        foreach(AnimationDetails animationDetails in _animationList) {
            randomValue -= animationDetails.weight;

            if(!(randomValue <= 0)) {
                continue;
            }

            _animator.Play(animationDetails.animationState);
            return;
        }
    }

    private void OnAnimationComplete() {
        PlayAnimationState();
    }

    private int GetTotalWeight() {
        int weight = 0;

        foreach(AnimationDetails animationDetails in _animationList) {
            weight += animationDetails.weight;
        }

        return weight;
    }
 }
