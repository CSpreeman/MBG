(function () {
    angular
        .module('mitmApp')
        .factory('commentService', CommentService);

    CommentService.$inject = ['$http'];

    function CommentService($http) {
        return {
            getAllComments : _getAllComments,
            getCommentsByBlogId: _getCommentsByBlogId,
            postComment: _postComment,
            deleteComment: _deleteComment
        };

        function _getAllComments() {
            return $http.get('api/comment')
                .then(getAllCommentsComplete)
                .catch(getAllCommentsFailed);

            function getAllCommentsComplete(response) {
                return response;
            }
            function getAllCommentsFailed(error) {
                console.log('Failed to get data', error)
            }
        }

        function _getCommentsByBlogId(id) {
            return $http.get('/api/comment/' + id)
                .then(getCommentsByBlogIdComplete)
                .catch(getCommentsByBlogIdFailed);

            function getCommentsByBlogIdComplete(response) {
                return response;
            }

            function getCommentsByBlogIdFailed(error) {
                console.log('Failed to get data', error);
            }

        }

        function _postComment(data) {
            return $http.post('/api/comment', data)
                .then(postCommentComplete)
                .catch(postCommentFailed);

            function postCommentComplete(response) {
                return response;
            }

            function postCommentFailed(error) {
                console.log('Failed to get data', error);
            }


        }

        function _deleteComment(id) {
            return $http.delete('/api/comment/' + id)
            .then(deleteCommentComplete)
            .catch(deleteCommentFailed);

            function deleteCommentComplete(response) {
                return response;
            }

            function deleteCommentFailed(error) {
                console.log('Failed to get data', error);
            }

        }
    }

})();
