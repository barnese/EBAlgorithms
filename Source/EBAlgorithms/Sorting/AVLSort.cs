﻿using System;
using System.Collections.Generic;
using EBAlgorithms.DataStructures;

namespace EBAlgorithms {

    public class AVLSort<T> where T : IComparable {
        private List<T> list;

        public AVLSort(List<T> list) {
            this.list = list;
        }

        public void Sort() {
            var tree = new AVLTree<T>(list);

            list.Clear();
            tree.TraverseInOrder((node) => {
                list.Add(node.key);
            });
        }
    }
}
